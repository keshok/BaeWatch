package ca.centennialcollege.comp313.baewatchandroidapp;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

public class LostPasswordActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_lost_password);
    }

    public void onSubmit(View view) {
        Toast.makeText(this, "E-mail successfully sent", Toast.LENGTH_SHORT).show();
    }
}
