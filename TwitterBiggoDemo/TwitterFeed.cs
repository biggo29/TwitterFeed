﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToTwitter;
using System.Text.RegularExpressions;



//namespace of the solution
namespace TwitterBiggoDemo
{
    public partial class TwitterFeed : Form
    {
        //single authorizer is a key that contains personal twitter account's
        //confidential informations. it initialize the user's idendity
        private SingleUserAuthorizer authorizer = new SingleUserAuthorizer
        {
            //here the user twitter application's inforrmation
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = "T6RBhUPEmk6I2ZW4fMZKzF3LE",
                ConsumerSecret = "GKSOz2FrAZrGje6HRFdil5XOcZkYYx3VpJ6odFjz83V0jN1YA0",
                AccessToken = "1011237469-dYWavRtWica75J3yLQw9D2VXccRWm4AGX0ltyAb",
                AccessTokenSecret = "JTnkVkZEXcxEnJNaBSkiSEN4zsCGT86WFxpsAqXmNcl2A"
            }
        };

        //initializing a list of curent news feeds
        private List<Status> currentTweets;

        //parent class of the form application
        public TwitterFeed()
        {
            //initializing the components
            InitializeComponent();
            //call the function that will display current 200 feeds from twitter
            GetMostRecent200HomeTimeLine();
            //clearing the textbox in which the feeds will be displayed
            lstTweetList.Items.Clear();

            //displaying the feed in text box right
            currentTweets.ForEach(tweet => lstTweetList.Items.Add(tweet.User.Name + ":" + tweet.Text));
            //display follow list in text box left
            GetSideBarList(GetFollowers()).ForEach(name => lstFollowNames.Items.Add(name));

        }


        //method that gets current 200 feeds form twitter of the user
        private void GetMostRecent200HomeTimeLine()
        {
            var twitterContext = new TwitterContext(authorizer);
            var tweets = from tweet in twitterContext.Status
                         where tweet.Type == StatusType.Home &&
                         tweet.Count == 200
                         select tweet;
            currentTweets = tweets.ToList();
        }

        //comment starts

        private List<string> GetFollowers()
        {
            List<string> results = new List<string>();

            var twitterContext = new TwitterContext(authorizer);

            var temp = Enumerable.FirstOrDefault(from friend in
                                                     twitterContext.Friendship
                                                 where friend.Type == FriendshipType.FollowersList &&
                                                    friend.ScreenName == "biggo29" &&
                                                    friend.Count == 200
                                                 select friend);

            if (temp != null)
            {
                temp.Users.ToList().ForEach(user => results.Add(user.Name));

                while (temp != null && temp.CursorMovement.Next != 0)
                {
                    temp = Enumerable.FirstOrDefault(from friend in
                                                         twitterContext.Friendship
                                                     where friend.Type == FriendshipType.FollowersList &&
                                                        friend.ScreenName == "biggo29" &&
                                                        friend.Count == 200 &&
                                                        friend.Cursor == temp.CursorMovement.Next
                                                     select friend);

                    if (temp != null) temp.Users.ToList().ForEach(user =>
                       results.Add(user.Name));
                }
            }

            return results;
        }

        private List<string> GetSideBarList(List<string> inputNames)
        {
            List<string> results = new List<string>();

            foreach (string name in inputNames)
            {
                int tweetCount = currentTweets.Count(tweet =>
                   tweet.User.Name == name);
                if (tweetCount > 0)
                {
                    results.Add(string.Format("{0} ({1})", name,
                       tweetCount));
                }
                else
                {
                    results.Add(string.Format("{0}", name));
                }
            }

            return results;
        }

        private void LstFollowNamesSelectedIndexChanged(object sender,
           System.EventArgs e)
        {
            lstTweetList.Items.Clear();
            var selectedName = (sender as ListBox).SelectedItem.ToString();
            string pattern = @"^(.*)\s\(\d{0,4}\)$";

            Match match = Regex.Match(selectedName, pattern);

            if (match.Success)
            {
                // We have a name with a count appended
                selectedName = match.Groups[1].Value.Trim();
            }

            foreach (var tweet in currentTweets.Where(tweet =>
                tweet.User.Name == selectedName))
            {
                lstTweetList.Items.Add(tweet.User.Name + ":" + tweet.Text);
            }

        }

        private void BtnShowAllClick(object sender, System.EventArgs e)
        {
            lstTweetList.Items.Clear();
            currentTweets.ForEach(tweet =>
               lstTweetList.Items.Add(tweet.User.Name + ":" + tweet.Text));
        }

        private List<Status> SearchTwitter(string searchTerm)
        {
            var twitterContext = new TwitterContext(authorizer);

            var srch =
               Enumerable.SingleOrDefault((from search in twitterContext.Search
                                           where search.Type == SearchType.Search &&
                                              search.Query == searchTerm &&
                                              search.Count == 200
                                           select search));
            if (srch != null && srch.Statuses.Count > 0)
            {
                return srch.Statuses.ToList();
            }

            return new List<Status>();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchTerm.Text))
            {
                MessageBox.Show("Please enter a term to search for");
                return;
            }

            var results = SearchTwitter(txtSearchTerm.Text);
            lstTweetList.Items.Clear();
            results.ForEach(tweet => lstTweetList.Items.Add(tweet.User.Name + ":" + tweet.Text));

        }


        //comment Ends
    }
}
