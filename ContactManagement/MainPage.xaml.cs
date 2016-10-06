using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ContactManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();        
            this.NavigationCacheMode = NavigationCacheMode.Required;

            /*lvContacts.ReorderMode = ListViewReorderMode.Enabled;
            lvContacts.SelectionMode = ListViewSelectionMode.Multiple;*/
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
            /*App app = Application.Current as App;
            if(app != null)
            {
                lvContacts.ItemsSource = app.contacts;                               

            }*/
            List<Contact> contacts = Proxy.getContacts();
            lvContacts.ItemsSource = contacts;
            //lvContacts.ItemsSource = new Settings().contacts;

            /*List<Contact> contacts = new List<Contact>()
            {
                new Contact()
                {
                    Name = "Rodgers",
                    PhoneNumber = "0727162205"
                },
                new Contact()
                {
                    Name = "Almodad",
                    PhoneNumber = "0718000659"
                },
                new Contact()
                {
                    Name = "Mike",
                    PhoneNumber = "0727162205"
                },
                new Contact()
                {
                    Name = "Mercy",
                    PhoneNumber = "0727162205"
                },
                new Contact()
                {
                    Name = "Kizzy",
                    PhoneNumber = "0727162205"
                },
                new Contact()
                {
                    Name = "Peter",
                    PhoneNumber = "0727162205"
                },
                new Contact()
                {
                    Name = "Antony",
                    PhoneNumber = "0727162205"
                },
                new Contact()
                {
                    Name = "Chebet",
                    PhoneNumber = "0727162205"
                }
            };
            lvContacts.ItemsSource = contacts;
             */



        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddContact));
        }

        private void OnListItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to ViewContact page
            Frame.Navigate(typeof(ViewContact), e.ClickedItem);
        }
        
    }
}
