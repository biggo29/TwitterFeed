using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToTwitter;

namespace TwitterBiggoDemo
{
    public partial class Form1 : Form
    {
        private SingleUserAuthorizer authorizer = new SingleUserAuthorizer
        {
            //this 4 attributes value will come from user's twitter application. 
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = "ConsumerKey",
                ConsumerSecret = "ConsumerSecret",
                AccessToken = "AccessToken",
                AccessTokenSecret = "AccessTokenSecret"
            }
        };
        private List<Status> currentTweets;
        private void GetMostRecent200HomeTimeLine()
        {
            var twitterContext = new TwitterContext(authorizer);
            var tweets = from tweet in twitterContext.Status
                         where tweet.Type == StatusType.Home &&
                         tweet.Count == 200
                         select tweet;
            currentTweets = tweets.ToList();
        }
        public Form1()
        {
            InitializeComponent();
            GetMostRecent200HomeTimeLine();
            lstTweetList.Items.Clear();
            currentTweets.ForEach(tweet =>
               lstTweetList.Items.Add(tweet.Text));
        }
    }
}
