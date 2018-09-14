using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web.Script.Serialization;
using static DragonsOfMugloar.GameAdventureMessagesJsonList;

namespace DragonsOfMugloar
{
    /// <summary>
    /// Interaction logic for GameStartDashBoard.xaml
    /// </summary>
    public partial class GameStartDashBoard : Page
    {
        public GameStartDashBoard()
        {
            InitializeComponent();
            HideReputationData();
            HideAllJsonTextBoxes();
            

            //DataContainer.currentGameId = GameAdventureNameValueLabel.Text;


        }

        private void HideAllJsonTextBoxes()
        {
            StartingGameAdventureNameLabel.Visibility = Visibility.Hidden;
            GameAdventureNameValueLabel.Visibility = Visibility.Hidden;
            StartingHighScoreLabel.Visibility = Visibility.Hidden;
            GameHighScoreValueLabel.Visibility = Visibility.Hidden;
            GameDataJsonTextBox.Visibility = Visibility.Hidden;
            CheckGameReputationJsonTextBox.Visibility = Visibility.Hidden;
            CheckGameAdventureSolvingJsonTextBox.Visibility = Visibility.Hidden;
            CheckGameAdventureMessagesJsonTextBox.Visibility = Visibility.Hidden;
            GameShopJsonTextBox.Visibility = Visibility.Hidden;
        }

        private void HideReputationData()
        {
            CheckGameReputationButton.Visibility = Visibility.Hidden;
            GameReputationPeopleLabel.Visibility = Visibility.Hidden;
            GameReputationPeopleValueLabel.Visibility = Visibility.Hidden;
            GameReputationStateLabel.Visibility = Visibility.Hidden;
            GameReputationStateValueLabel.Visibility = Visibility.Hidden;
            GameReputationUnderworldLabel.Visibility = Visibility.Hidden;
            GameReputationUnderWorldValueLabel.Visibility = Visibility.Hidden;
        }
        private void ShowReputationData()
        {
            GameReputationPeopleLabel.Visibility = Visibility.Visible;
            GameReputationPeopleValueLabel.Visibility = Visibility.Visible;
            GameReputationStateLabel.Visibility = Visibility.Visible;
            GameReputationStateValueLabel.Visibility = Visibility.Visible;
            GameReputationUnderworldLabel.Visibility = Visibility.Visible;
            GameReputationUnderWorldValueLabel.Visibility = Visibility.Visible;
        }


        private async void StartNewGameButton_Click(object sender, RoutedEventArgs e)
        {
            CheckGameAdventureMessagesListBox.Items.Clear();
            GameShopItemsListBox.Items.Clear();
            await GetGameDataJson();
        }

        private async Task GetGameDataJson()
        {
            HttpClient httpClient = new HttpClient();

            string correctNewGameStartURL = ("https://www.dragonsofmugloar.com/api/v2/game/start");


            var response = await httpClient.PostAsync(correctNewGameStartURL, null);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            //MessageBox.Show(content);
            GameDataJsonTextBox.Text = content;
            //MessageBox.Show(GameDataJsonTextBox.Text);
            DeserializeGameData(GameDataJsonTextBox.Text);
            DataContainer.currentGameId = GameAdventureNameValueLabel.Text;
            return;
        }

        private void DeserializeGameData(string JSON)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            GameDataJson gameDataJson = new GameDataJson();
            gameDataJson = serializer.Deserialize<GameDataJson>(JSON);

            GameAdventureNameValueLabel.Text = gameDataJson.gameId;
            GameLivesValueLabel.Text = gameDataJson.lives.ToString();
            GameGoldValueLabel.Text = gameDataJson.gold.ToString();
            GameDragonLevelValue.Text = gameDataJson.level.ToString();
            GameScoreValueLabel.Text = gameDataJson.score.ToString();
            GameHighScoreValueLabel.Text = gameDataJson.highScore.ToString();
            GameTurnValueLabel.Text = gameDataJson.turn.ToString();

        }

        private void MissionWasSuccessful(string JSON)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            GameAdventureSolvingJson gameAdventure = new GameAdventureSolvingJson();
            gameAdventure = serializer.Deserialize<GameAdventureSolvingJson>(JSON);
            MissionWasSuccessfulValueLabel.Text = gameAdventure.success.ToString();
            GameLivesValueLabel.Text = gameAdventure.lives.ToString();
            GameGoldValueLabel.Text = gameAdventure.gold.ToString();
            GameScoreValueLabel.Text = gameAdventure.score.ToString();
            GameHighScoreValueLabel.Text = gameAdventure.highScore.ToString();
            GameTurnValueLabel.Text = gameAdventure.turn.ToString();
            MessageBox.Show(gameAdventure.message);
        }
        private void ShoppingWasSuccessful(string JSON)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            GameShoppingJson gameShopping = new GameShoppingJson();
            gameShopping = serializer.Deserialize<GameShoppingJson>(JSON);
            ItemPurchaseWasSuccessfulValueLabel.Text = gameShopping.shoppingSuccess.ToString();
            GameLivesValueLabel.Text = gameShopping.lives.ToString();
            GameGoldValueLabel.Text = gameShopping.gold.ToString();
            GameTurnValueLabel.Text = gameShopping.turn.ToString();
            GameDragonLevelValue.Text = gameShopping.level.ToString();
            
        }

        private async void CheckGameReputationButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GameLivesValueLabel.Text))
            {
                MessageBox.Show("Please start the game!");
            }
            else
            {
                ShowReputationData();
            HttpClient httpClient = new HttpClient();

            string currentGameReputationURL = ("https://www.dragonsofmugloar.com/api/v2/" + GameAdventureNameValueLabel.Text + "/investigate/reputation");

            var value = new Dictionary<string, string>
                     {
                        { "gameId", GameAdventureNameValueLabel.Text }
                        

                     };
            var postContent = new FormUrlEncodedContent(value);

            var response = await httpClient.PostAsync(currentGameReputationURL, postContent);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            CheckGameReputationJsonTextBox.Text = content;

            DeserializeGameReputationData(CheckGameReputationJsonTextBox.Text);
                }
        }

        private void DeserializeGameReputationData(string text)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            GameReputationJson gameReputationJson = new GameReputationJson();


            GameReputationPeopleValueLabel.Text = gameReputationJson.people.ToString();
            GameReputationStateValueLabel.Text = gameReputationJson.state.ToString();
            GameReputationUnderWorldValueLabel.Text = gameReputationJson.underworld.ToString();
        }

        private void CheckForAdventuresButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(GameLivesValueLabel.Text))
            {
                MessageBox.Show("Please start the game!");
            }
            else
            {
                MessageBox.Show("To choose adventure to solve, just double click on desired adventure.");

            CheckForAdventures();
            }

        }

        private void CheckForAdventures()
        {
            CheckGameAdventureMessagesListBox.Items.Clear();
            WebClient webClient = new WebClient();


            string currentGameAdventureMessagesURL = ("https://www.dragonsofmugloar.com/api/v2/" + DataContainer.currentGameId + "/messages");

            string adventureMessages = webClient.DownloadString(currentGameAdventureMessagesURL);
            CheckGameAdventureMessagesJsonTextBox.Text = adventureMessages;
            

            DeserializeGameAdventureMessagesData(CheckGameAdventureMessagesJsonTextBox.Text);

        }
        public static string Base64Decode(string base64EncodedData)
        {
            //töötab
            string s = base64EncodedData.Trim().Replace(" ", "+");
            if (s.Length % 4 > 0)
                s = s.PadRight(s.Length + 4 - s.Length % 4, '=');
            return Encoding.UTF8.GetString(Convert.FromBase64String(s));


            //viga lõi sisse “Invalid length for a Base-64 char array” see alumine osa
            //var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            //return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        private void DeserializeGameAdventureMessagesData(string JSON)
        {
            var newline = Environment.NewLine;
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<GameAdventureMessages> correctGameAdventureMessagesJsonList = (List<GameAdventureMessages>)javaScriptSerializer.Deserialize(JSON, typeof(List<GameAdventureMessages>));
            
            foreach (GameAdventureMessages messages in correctGameAdventureMessagesJsonList)
            {
                //kontroll, kas on encrypt parameeter sees, kui on siis kustutab selle ära
                if (messages.encrypted != null)
                {
                    
                    var adventureMessage =
                    ("Adventure id: ") + Base64Decode(messages.adId) + newline +
                    ("Message: ") + Base64Decode(messages.message) + newline +
                    ("Reward: ") + messages.reward + newline +
                    ("Expires in: ") + messages.expiresIn + (" turns") + newline +
                    ("Encryption: ") + messages.encrypted + newline +
                    ("Probability: ") + Base64Decode(messages.probability);
                    CheckGameAdventureMessagesListBox.Items.Add(adventureMessage);
                }
                else
                {
                    //ilma encryptita
                    var adventureMessage =
                    //Ecrypted on koguaeg null, kui encrypted parameetriga adventure valida, siis viskabki http400.
                    
                    ("Adventure id: ") + messages.adId + newline +
                    ("Message: ") + messages.message + newline +
                    ("Reward: ") + messages.reward + newline +
                    ("Expires in: ") + messages.expiresIn + (" turns") + newline +
                    ("Probability: ") + messages.probability;
                    CheckGameAdventureMessagesListBox.Items.Add(adventureMessage);
                }
            }
        }

        private async void CheckGameAdventureMessagesListBox_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            string selectedAdventure = CheckGameAdventureMessagesListBox.SelectedItem.ToString();
            if(selectedAdventure != null)
            {
                //DeserializeGameData(GameDataJsonTextBox.Text);
            await SolveAdventure();
                CheckForAdventures();
                DeserializeGameAdventureMessagesData(CheckGameAdventureMessagesJsonTextBox.Text);
                if (GameLivesValueLabel.Text == 1.ToString())
                {
                    GameLivesValueLabel.Foreground = new SolidColorBrush(Colors.Red);
                }
                else if(GameLivesValueLabel.Text != 1.ToString())
                {
                    GameLivesValueLabel.Foreground = new SolidColorBrush(Colors.Black);
                }

            }

        }

        private async Task SolveAdventure()
        {
            GameAdventureNameValueLabel.Text = DataContainer.currentGameId;
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<GameAdventureMessages> correctGameAdventureMessagesJsonList = (List<GameAdventureMessages>)javaScriptSerializer.Deserialize(CheckGameAdventureMessagesJsonTextBox.Text, typeof(List<GameAdventureMessages>));

            string selectedAdventure = CheckGameAdventureMessagesListBox.SelectedItem.ToString();
            foreach (GameAdventureMessages message in correctGameAdventureMessagesJsonList)
            {


                if (message.adId.Contains("="))
                {
                    message.adId = Base64Decode(message.adId);
                    
                }
                else if(!message.adId.Contains("="))
                {
                    message.adId = message.adId;
                }
                
                if (selectedAdventure.Contains(message.adId))
                {
                    if (message.adId.Contains("="))
                    {
                        DataContainer.selectedAdventureID = Base64Decode(message.adId);
                    }
                    else
                    {

                    DataContainer.selectedAdventureID = message.adId;
                    }
                    GameAdventureNameValueLabel.Text = DataContainer.currentGameId;
                    HttpClient httpClient = new HttpClient();

                    string currentGameReputationURL = ("https://www.dragonsofmugloar.com/api/v2/" + DataContainer.currentGameId + "/solve/" + DataContainer.selectedAdventureID);

                    var value = new Dictionary<string, string>
                     {
                        { "gameId", DataContainer.currentGameId },
                        { "adId",  DataContainer.selectedAdventureID }



                     };

                    var postContent = new FormUrlEncodedContent(value);
                    //MessageBox.Show(postContent.ToString());
                    //var response = httpClient.PostAsync(correctNewSiteURL, content);

                    var response = await httpClient.PostAsync(currentGameReputationURL, postContent);
                    //exception 400 bad request vms, uuendatud koodis viga ei esine
                    //response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {

                    //labelite uuendamine
                    string content = await response.Content.ReadAsStringAsync();
                    CheckGameAdventureSolvingJsonTextBox.Text = content;
                        //MessageBox.Show(content);
                    //DeserializeGameData(CheckGameAdventureSolvingJsonTextBox.Text);
                    MissionWasSuccessful(CheckGameAdventureSolvingJsonTextBox.Text);
                        //MessageBox.Show(response.ToString());

                    }
                    else
                    {
                        MessageBox.Show("Something went wrong with adventure (id:" + DataContainer.selectedAdventureID + ")! Please choose another mission!");
                    }

                

                }
    
            }
        }

        private void GameGoToTheShopButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GameLivesValueLabel.Text))
            {
                MessageBox.Show("Please start the game!");
            }
            else
            {
                MessageBox.Show("To buy item from the shop, just double click on desired item.");
                CheckGameShopItems();
            }
        }

        private void CheckGameShopItems()
        {
            GameShopItemsListBox.Items.Clear();
            WebClient webClient = new WebClient();
            string currentGameShopItemsURL = ("https://www.dragonsofmugloar.com/api/v2/" + DataContainer.currentGameId + "/shop");
            string shopItems = webClient.DownloadString(currentGameShopItemsURL);
            GameShopJsonTextBox.Text = shopItems;
            DeserializeGameShopItemsData(GameShopJsonTextBox.Text);
        }

        private void DeserializeGameShopItemsData(string JSON)
        {
            var newline = Environment.NewLine;
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<GameShopItemsJson.ShopItems> correctGameShopItemsJsonList = (List<GameShopItemsJson.ShopItems>)javaScriptSerializer.Deserialize(JSON, typeof(List<GameShopItemsJson.ShopItems>));

            foreach (GameShopItemsJson.ShopItems shopItems in correctGameShopItemsJsonList)
            {
                var adventureShopItems =

                    ("Shop item id: ") + shopItems.id + newline +
                    ("Shop item name: ") + shopItems.name + newline +
                    ("Cost: ") + shopItems.cost + newline;
                    
                GameShopItemsListBox.Items.Add(adventureShopItems);
            }
        }



        private async void GameShopItemsListBox_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            string selectedShopItem = GameShopItemsListBox.SelectedItem.ToString();
            if (selectedShopItem != null)
            {
                //DeserializeGameData(GameDataJsonTextBox.Text);
                await ShopGameItems();
                CheckGameShopItems();
                CheckForAdventures();
                //DeserializeGameShopItemsData(GameShopJsonTextBox.Text);
                if (GameLivesValueLabel.Text == 1.ToString())
                {
                    GameLivesValueLabel.Foreground = new SolidColorBrush(Colors.Red);
                }
                else if (GameLivesValueLabel.Text != 1.ToString())
                {
                    GameLivesValueLabel.Foreground = new SolidColorBrush(Colors.Black);
                }
                if (ItemPurchaseWasSuccessfulValueLabel.Text == "False")
                {
                    MessageBox.Show("You don´t have not enough gold, to buy this item!");
                    CheckForAdventures();
                }
            }
        }

        private async Task ShopGameItems()
        {
            GameAdventureNameValueLabel.Text = DataContainer.currentGameId;
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<GameShopItemsJson.ShopItems> correctGameShopItemsJsonList = (List<GameShopItemsJson.ShopItems>)javaScriptSerializer.Deserialize(GameShopJsonTextBox.Text, typeof(List<GameShopItemsJson.ShopItems>));

            foreach (GameShopItemsJson.ShopItems shopItems in correctGameShopItemsJsonList)
            {
                string selectedShopItem = GameShopItemsListBox.SelectedItem.ToString();
                //MessageBox.Show(shopItems.id);
                if (selectedShopItem.Contains(shopItems.id))
                {
                    DataContainer.currentGameShopItemId = shopItems.id;
                    GameAdventureNameValueLabel.Text = DataContainer.currentGameId;

                    HttpClient httpClient = new HttpClient();

                    string currentGameReputationURL = ("https://www.dragonsofmugloar.com/api/v2/" + DataContainer.currentGameId + "/shop/buy/" + DataContainer.currentGameShopItemId);

                    var value = new Dictionary<string, string>
                     {
                        { "gameId", DataContainer.currentGameId },
                        { "itemId",  DataContainer.currentGameShopItemId }



                     };
                    var postContent = new FormUrlEncodedContent(value);
                    

                    var response = await httpClient.PostAsync(currentGameReputationURL, postContent);
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {

                    string content = await response.Content.ReadAsStringAsync();
                    GameShopJsonTextBox.Text = content;

                        //DeserializeGameData(GameShopJsonTextBox.Text);
                        ShoppingWasSuccessful(GameShopJsonTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong! Please choose another shop item!");
                    }

                }
            }
        }

    }

}


