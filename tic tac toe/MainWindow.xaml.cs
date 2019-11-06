using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace tic_tac_toe
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player playerX;
        private Player playerO;

        private Player startingPlayer;
        private Player thisPlayerTurn;

        private int turn;
        public MainWindow()
        {
            InitializeComponent();

            playerX = new Player("X", "Player 1");
            playerO = new Player("O", "Player 2");

            startingPlayer = playerX;
            thisPlayerTurn = playerX;

            turn = 0;
            labelUpdate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            turn++;
            Button button = (Button)sender;

            button.Content = thisPlayerTurn.Symbol;
            button.IsEnabled = false;


            if (thisPlayerTurn == playerO)
                thisPlayerTurn = playerX;
            else if (thisPlayerTurn == playerX)
                thisPlayerTurn = playerO;

            labelUpdate();

            if(checkWinner() == true)
            {
                if (thisPlayerTurn == playerO)
                    thisPlayerTurn = playerX;
                else if (thisPlayerTurn == playerX)
                    thisPlayerTurn = playerO;
                gotWinner();
            }

            if(turn == 9)
                checkDraw();
        }

        private void labelUpdate()
        {
            StringBuilder scoreLabelContent = new StringBuilder();
            scoreLabelContent.AppendFormat("{0}  {1}:{2}  {3}", playerX.Name, playerX.Score, playerO.Score, playerO.Name);
            scoreLabel.Content = scoreLabelContent;

            infoLabel.Content = thisPlayerTurn.Name + " twój ruch";
        }

        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            button00.Content = button10.Content = button20.Content = button01.Content = button11.Content = button21.Content = button02.Content = button12.Content = button22.Content = "";
            button00.IsEnabled = button10.IsEnabled = button20.IsEnabled = button01.IsEnabled = button11.IsEnabled = button21.IsEnabled = button02.IsEnabled = button12.IsEnabled = button22.IsEnabled = true;
            playAgainArea.Visibility = Visibility.Hidden;
            GameArea.Visibility = Visibility.Visible;
            turn = 0;

            if (startingPlayer == playerO)
            {
                thisPlayerTurn = playerX;
                startingPlayer = playerX;
            }
            else if (startingPlayer == playerX)
            {
                thisPlayerTurn = playerO;
                startingPlayer = playerO;
            }

            labelUpdate();
        }

        public void checkDraw()
        {
            winnerLabel.Content = "Remis";
            playAgainArea.Visibility = Visibility.Visible;
            GameArea.Visibility = Visibility.Hidden;
        }

        public void gotWinner()
        {
            playAgainArea.Visibility = Visibility.Visible;
            GameArea.Visibility = Visibility.Hidden;

            winnerLabel.Content = thisPlayerTurn.Name + " wygrał rundę";
            if (thisPlayerTurn == playerO)
                playerO.Score += 1;
            else if (thisPlayerTurn == playerX)
                playerX.Score += 1;
        }

        public bool checkWinner()
        {
            if ((button00.Content.ToString() == button01.Content.ToString()) && (button01.Content.ToString() == button02.Content.ToString()) && (button00.Content.ToString() != ""))
                return true;
            else if ((button10.Content.ToString() == button11.Content.ToString()) && (button11.Content.ToString() == button12.Content.ToString()) && (button10.Content.ToString() != ""))
                return true;
            else if ((button20.Content.ToString() == button21.Content.ToString()) && (button21.Content.ToString() == button22.Content.ToString()) && (button20.Content.ToString() != ""))
                return true;

            else if ((button00.Content.ToString() == button10.Content.ToString()) && (button10.Content.ToString() == button20.Content.ToString()) && (button00.Content.ToString() != ""))
                return true;
            else if ((button01.Content.ToString() == button11.Content.ToString()) && (button11.Content.ToString() == button21.Content.ToString()) && (button01.Content.ToString() != ""))
                return true;
            else if ((button02.Content.ToString() == button12.Content.ToString()) && (button12.Content.ToString() == button22.Content.ToString()) && (button02.Content.ToString() != ""))
                return true;

            else if ((button00.Content.ToString() == button11.Content.ToString()) && (button11.Content.ToString() == button22.Content.ToString()) && (button00.Content.ToString() != ""))
                return true;
            else if ((button20.Content.ToString() == button11.Content.ToString()) && (button11.Content.ToString() == button02.Content.ToString()) && (button20.Content.ToString() != ""))
                return true;

            else return false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
