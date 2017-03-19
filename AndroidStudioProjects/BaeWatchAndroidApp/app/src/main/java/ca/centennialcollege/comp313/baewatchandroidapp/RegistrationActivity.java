package ca.centennialcollege.comp313.baewatchandroidapp;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

public class RegistrationActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration);
    }

    public void onRegister(View view) {
        Toast.makeText(this, "User account successfully created", Toast.LENGTH_SHORT).show();
    }
}
