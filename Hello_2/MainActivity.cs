using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Threading.Tasks;

//using System.Threading;   // don't use this for threading
using Java.Lang;            // Java version of threading works better

// Udemy ex: Grant K. course, section 3.17 - Slow Text Mover
// Need a timer to slow down the test moving

namespace Hello_2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button btn = FindViewById<Button>(Resource.Id.button1);
            TextView txtView = FindViewById<TextView>(Resource.Id.textView1);
            EditText editTxt = FindViewById<EditText>(Resource.Id.editText1);

            btn.Click += delegate {
                txtView.Text = "";

                while (editTxt.Text.Length > 0) {
                    // get letter to add
                    var letter = editTxt.Text.Substring(0, 1); // substring starts at 0, length=1
                    txtView.Text = txtView.Text + letter;  // add one letter at a time to txtView
                    editTxt.Text = editTxt.Text.Substring(1); // substring starting at pos=1 to end of string
                }   


                    // this code is running in the UI thread (deals with UI & user interactions)
                    // You don't want to block this thread: UI response will be sluggish,
                    // or will get an "Application Not Responding" & may even crash
                    // So don't create a timer within the UI thread: create a new thread

                    // anything here is taken off the UI thread & doesn't block it
                    // so application remains repsonsive
                    /*Task.Factory.StartNew(() => {

                        //txtView.Text = "editTxt length = " + editTxt.Length().ToString();  // add one letter at a time to txtView
                        txtView.Text = "editTxt length = " + editTxt.Text.Length;  // add one letter at a time to txtView
                        //string letter;

                        while (editTxt.Text.Length > 0) {
                            // we're not in the UI thread, so we have to get back to it for UI work
                            RunOnUiThread(() => {
                                // get letter to add
                                //if(editTxt.Text.Length > 0)
                                  var letter = editTxt.Text.Substring(0,1); // substring starts at 0, length=1
                                txtView.Text = txtView.Text + letter;  // add one letter at a time to txtView
                                //txtView.Text = txtView.Text + 'a';  // add one letter at a time to txtView
                                editTxt.Text = editTxt.Text.Substring(1); // substring starting at pos=1 to end of string

                            });
                        
                        // Sleep() blocks execution: that's why we run this in separate thread 
                        Thread.Sleep(100); // 1000 ms = 1 sec
                        }
                    });*/
                
                
                editTxt.Text = "";
            };

        }
    }
}

