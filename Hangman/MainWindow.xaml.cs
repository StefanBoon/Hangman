using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Hangman
{
    public partial class MainWindow : Window
    {
        /// objects that need to be created in order to change them in the button voids:
        private string input = "";
        private string word = "";
        List<int> indexes = new List<int>();
        int tryMax = 10;
        int tryLeft = 99;
        bool endOfGame = false; /// to know whether the game has 

        public MainWindow()  {InitializeComponent(); gameStart.Content= "Start Game"; }
       
        private void gameStart_Click(object sender, RoutedEventArgs e)/// Start Game button
        {
           
            boxx.Focus();
            tryLeft = tryMax;
            var random = new Random();
            var list = new List<string> { "woord", "muziek", "chronologisch", "autobandventieldopje", "palet","toetsenbord","ziekenhuis","indrukwekkend","wandeling","sporten","studeren","oorlog"
                ,"verbaal","fotosynthese","flits","lamp","gaan","banaan","doel","familie","overval","uitermate","bal","noot","expressie","gitaar","muziek"
                ,"beeldscherm","installatie","installeren","gezamelijk","ongediertebestrijding","antropomorfisme","profiel","staaltje","groen","versnelling"
            ,"zeepaard","tentamen","allemaal","titratie","metalen","stormram","snoezepoes","liften","aardstraal","pootje",
"kopstuk","stuntman","uitduiden","lieden","aanbouw","riool","neerzetten","brancard","oppoetsen","herleven",
"mopperen","zeezand","voordat","peuken","sorbet","tabakszak","oorlel","astronaut","koe","kat","uier","hond","patat","hamburger","mayonaise","quiz","xylofoon","rex","climax","bord",
                "zand","zandloper","straat","wegwijzer","piratenschip","lantaarn" };///,"geneesmiddelenvergoedingssysteem","lagekostenluchtvaartmaatschappij","elektriciteitsproductiemaatschappij"};
            int index = random.Next(list.Count);
            word = list[index];
            string unders = new String('_', word.Length);
            string[] underss = new[] { unders };
            List<string> Under = new List<string>();
            foreach (char u in unders){
                 Under.Add(" ");
             }
            Under.Add(" ");
            string Underz = string.Join("-", Under.ToArray());
            underScoreLab.Content = Underz;
            tryLab.Content = "Attempts left: "+tryMax;
            testLab.Content = " ";
            gameStart.Content= "New Game"; // when Start Game button is clicked, this changes the button text to New Game
            // resetting variables when new game is created:
            indexes = new List<int>();
            tryLeft = 10;
            Line1.Visibility = Visibility.Hidden;
            Line2.Visibility = Visibility.Hidden;
            Line3.Visibility = Visibility.Hidden;
            Line4.Visibility = Visibility.Hidden;
            Line5.Visibility = Visibility.Hidden;
            Line6.Visibility = Visibility.Hidden;
            Line7.Visibility = Visibility.Hidden;
            Line8.Visibility = Visibility.Hidden;
            Line9.Visibility = Visibility.Hidden;
            Line10.Visibility = Visibility.Hidden;
            Line11.Visibility = Visibility.Hidden;
            Line12.Visibility = Visibility.Hidden;
            Line13.Visibility = Visibility.Hidden;
            Line14.Visibility = Visibility.Hidden;
            happyMan.Visibility = Visibility.Hidden;
            endOfGame = false;
        }



        


        private void transBut_Click(object sender, RoutedEventArgs e)/// Submit button
        {
            if (tryLeft == 0) {MessageBox.Show("Stop! It's already dead!\nPlease start a new game."); }

            if (gameStart.Content == "Start Game") {  MessageBox.Show("Please start the game first."); }

            /// only let this button do something when a game has been started before/i.e. when the start button is "New Game"
            if (gameStart.Content == "New Game" && tryLeft != 0)
            {
            input = boxx.Text;
            input = input.ToLower();

            char[] charArray = word.ToCharArray();
            if (word.Contains(input))
            {
                    int num = 0;
                foreach (char b in charArray)
                {
                    string bet = b.ToString();
                    if (input == bet)
                    {
                        indexes.Add(num);
                    }
                    num = num + 1;
                }

                int numy = 0;
                string[] str = new string[] { };
                List<string> newWord = new List<string>();
                 
                foreach (char c in word)
                {
                    if (indexes.Contains(numy))
                    {
                        newWord.Add(c.ToString());
                        str = newWord.ToArray();
                    }
                    else
                    {
                        newWord.Add(" ");
                        str = newWord.ToArray();
                    }
                     numy = numy + 1;
                }
                    
                    string indexies = string.Join(" ", indexes.ToArray());
                    string wordProgress = string.Join(" ", str.ToArray());
                    

                    testLab.Content = wordProgress;
                    int count = wordProgress.Count(f => f == ' ');
                    if(count-word.Length+1 == 0)
                    {
                        endOfGame = true;
                        Line1.Visibility = Visibility.Visible;
                        Line2.Visibility = Visibility.Visible;
                        Line3.Visibility = Visibility.Visible;
                        Line4.Visibility = Visibility.Visible;
                        Line5.Visibility = Visibility.Visible;
                        Line6.Visibility = Visibility.Hidden;
                        Line7.Visibility = Visibility.Hidden;
                        Line8.Visibility = Visibility.Hidden;
                        Line9.Visibility = Visibility.Hidden;
                        Line10.Visibility = Visibility.Hidden;
                        Line11.Visibility = Visibility.Hidden;
                        Line12.Visibility = Visibility.Hidden;
                        Line13.Visibility = Visibility.Hidden;
                        Line14.Visibility = Visibility.Hidden;
                        happyMan.Visibility = Visibility.Visible;
                        if(tryLeft == 1) { MessageBox.Show("You have won!\nYou won with " + tryLeft + " attempt left, close call!"); } else { 
                        if (tryLeft > (tryMax-1) / 2) { MessageBox.Show("You have won!\nYou won with " + tryLeft + " attempts left, nice job!"); } 
                        else { 
                        MessageBox.Show("You have won!\nYou won with " + tryLeft + " attempts left, close call!"); 
                        }}
                    }

                }
                else
                {
                    tryLeft = tryLeft - 1;
                }
                if (!endOfGame) { /// if the game has ended and for example tryLeft is below 8, you do not want to display Line3
                if(tryLeft < 10) { Line1.Visibility = Visibility.Visible; }
                if (tryLeft < 9) { Line2.Visibility = Visibility.Visible; }
                if (tryLeft < 8) { Line3.Visibility = Visibility.Visible; }
                if (tryLeft < 7) { Line4.Visibility = Visibility.Visible; }
                if (tryLeft < 6) { Line5.Visibility = Visibility.Visible; }
                if (tryLeft < 5) { Line6.Visibility = Visibility.Visible; }
                if (tryLeft < 4) { Line7.Visibility = Visibility.Visible; }
                if (tryLeft < 3) { Line8.Visibility = Visibility.Visible; }
                if (tryLeft < 2) { Line9.Visibility = Visibility.Visible; }
                if (tryLeft == 0) {Line10.Visibility = Visibility.Visible;
                    Line11.Visibility = Visibility.Visible;
                    Line12.Visibility = Visibility.Visible;
                    Line13.Visibility = Visibility.Visible;
                    Line14.Visibility = Visibility.Visible;
                    tryLab.Content = "Attempts left: " + tryLeft;
                    MessageBox.Show("Oh dear, you are dead!\nThe right answer was: "+word);
                }}
                
                tryLab.Content = "Attempts left: " + tryLeft;
                boxx.Text = String.Empty;
                boxx.Focus();
            }
        }

        private void boxx_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.Key == Key.Enter)
            {
                transBut.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); ;
            }
        }
    }

        
}

