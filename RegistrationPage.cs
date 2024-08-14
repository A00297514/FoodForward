using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Database;
using Java.Util;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YourNamespace
{
    [Activity(Label = "RegistrationLayout")]
    public class RegistrationLayout : Activity
    {
        private EditText edName, edPhone, edEmail, edPassword, edConfirmPassword;
        private Button btnRegister;
        private TextView txtRegLogin, txtTerms;
        private CheckBox cbTerms;
        private ProgressDialog progressDialog;
        private FirebaseAuth mAuth;
        private DatabaseReference regData;
        private string email, password;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegistrationLayout);

            // Initialize Firebase Auth
            mAuth = FirebaseAuth.Instance;
            regData = FirebaseDatabase.Instance.GetReference("Registration");

            // Initialize views
            edName = FindViewById<EditText>(Resource.Id.edName);
            edPhone = FindViewById<EditText>(Resource.Id.edPhone);
            edEmail = FindViewById<EditText>(Resource.Id.edEmail);
            edPassword = FindViewById<EditText>(Resource.Id.edPassword);
            edConfirmPassword = FindViewById<EditText>(Resource.Id.edConfirmPassword);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            txtRegLogin = FindViewById<TextView>(Resource.Id.txtRegLogin);
            txtTerms = FindViewById<TextView>(Resource.Id.txtTerms);
            cbTerms = FindViewById<CheckBox>(Resource.Id.cbTerms);

            // Set click listeners
            btnRegister.Click += BtnRegister_Click;
            txtRegLogin.Click += TxtRegLogin_Click;
            txtTerms.Click += TxtTerms_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            email = edEmail.Text.Trim();
            password = edPassword.Text.Trim();
            string name = edName.Text.Trim();
            string phoneNumber = edPhone.Text.Trim();
            string cPassword = edConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                edName.Error = "Enter Name";
            }
            else if (string.IsNullOrEmpty(phoneNumber))
            {
                edPhone.Error = "Enter Phone Number";
            }
            else if (string.IsNullOrEmpty(email))
            {
                edEmail.Error = "Enter Email";
            }
            else if (string.IsNullOrEmpty(password))
            {
                edPassword.Error = "Enter Valid Password";
            }
            else if (string.IsNullOrEmpty(cPassword))
            {
                edConfirmPassword.Error = "Re-enter password is empty";
            }
            else if (!password.Equals(cPassword))
            {
                Toast.MakeText(this, "Both passwords are not same", ToastLength.Short).Show();
            }
            else if (!Android.Util.Patterns.EmailAddress.Matcher(email).Matches())
            {
                Toast.MakeText(this, "Please Enter a valid email", ToastLength.Short).Show();
            }
            else if (phoneNumber.Length < 10)
            {
                Toast.MakeText(this, "Please Enter a valid phone number", ToastLength.Short).Show();
            }
            else if (!cbTerms.Checked)
            {
                Toast.MakeText(this, "Please agree to our terms to continue", ToastLength.Short).Show();
            }
            else
            {
                progressDialog = new ProgressDialog(this);
                progressDialog.SetTitle("You are being registered...");
                progressDialog.Show();

                mAuth.CreateUserWithEmailAndPassword(email, password)
                    .AddOnCompleteListener(this, new OnCompleteListener<AuthResult>((task) =>
                    {
                    if (task.IsSuccessful)
                    {
                        // Save user details
                        var splashPrefs = GetSharedPreferences("splash", FileCreationMode.Private);
                        var splashEditor = splashPrefs.Edit();
                        splashEditor.PutBoolean("isLogin", true);
                        splashEditor.PutString("email", email);
                        splashEditor.Apply();

                        var sharedPrefs = GetSharedPreferences("Leftovers", FileCreationMode.Private);
                        var editor = sharedPrefs.Edit();
                        editor.PutBoolean("isLogin", true);
                        editor.PutString("email", email);
                        editor.PutString("name", name);
                        editor.PutString("phone", phoneNumber);
                        editor.Apply();

                        Toast.MakeText(this, "Click the link sent to your email for registration", ToastLength.Long).Show();

                        var user = mAuth.CurrentUser;
                        user.SendEmailVerification()
                            .AddOnCompleteListener(new OnCompleteListener<Void>((verifyTask) =>
                            {
                            if (verifyTask.IsSuccessful)
                            {
                                Timer timer = new Timer();
                                timer.Schedule(new TimerTask()
                                {
                                            public override void Run()
        {
            user.Reload();
            if (user.IsEmailVerified)
            {
                timer.Cancel();

                string key = regData.Push().Key;
                var registration = new Registration(name, phoneNumber, email);
                regData.Child(key).SetValue(registration);

                RunOnUiThread(() =>
                {
                if (progressDialog.IsShowing)
                {
                    progressDialog.Dismiss();

                    var homeScreen = new Intent(this, typeof(LoginActivity));
                    StartActivity(homeScreen);
                    Finish();


