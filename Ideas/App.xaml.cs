using Ideas.Common;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Newtonsoft.Json;                      // JSON.net
using System.Collections.ObjectModel;       // Observable Collection 
using Ideas.DataModel;
using Ideas.JSON; 


// The Grid App template is documented at http://go.microsoft.com/fwlink/?LinkId=234226

namespace Ideas
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {

        public static Idea Selected_Idea = null; 
        private ObservableCollection<Idea> _ideas;
        public ObservableCollection<Idea> Ideas 
        {
            get { return _ideas; }
            set { _ideas = value; }
        }
        
        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                //Associate the frame with a SuspensionManager key                                
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }
            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(GroupedItemsPage), "AllGroups"))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();

            // Get the roaming folder for the application
            StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;

            Idea testIdea = new Idea(); // { UniqueId = 1, Title = "Ideas", Overview = "Overview", Notes = "Notes" };
            testIdea.UniqueId = 21;
            testIdea.Title = "Ideas";
            testIdea.Overview = "Overview";
            testIdea.Notes = "Notes";
            Idea testIdea2 = new Idea(); // { UniqueId = 1, Title = "Ideas", Overview = "Overview", Notes = "Notes" };
            testIdea2.UniqueId = 2;
            testIdea2.Title = "Caffeine Calculator";
            testIdea2.Overview = "Overview";
            testIdea2.Notes = "Notes";
            List<Idea> ideaList = new List<Idea>();
            ideaList.Add(testIdea);
            ideaList.Add(testIdea2);
            var JSON_Ideas = JSON_Idea_Converter.JsonSerializer<List<Idea>>(ideaList); 

            try
            {
                // Look for Ideas.JSON file in the roaming folder 
                var file = await roamingFolder.GetFileAsync("Ideas.JSON");


                await FileIO.WriteTextAsync(file, JSON_Ideas); 

                // Read the entire file 
                var JSON_input = await FileIO.ReadTextAsync(file);

                // Deserialize all of the ideas in the file into a list of ideas
                List<Idea> deserialized = JsonConvert.DeserializeObject<List<Idea>>(JSON_input,
  new JSON_Idea_Converter());

                // Put all of the ideas into the global Observable Collection of Ideas
                Ideas = new ObservableCollection<Idea>(deserialized); 



            }
            catch(Exception ex)
            {
                roamingFolder.CreateFileAsync("Ideas.JSON");
            }
            
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
}
