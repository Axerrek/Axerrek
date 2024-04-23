package com.app.console;

import com.app.modules.Megaphone;
import com.app.modules.Speaker;

public class Console {


    public static void run() {

        Speaker speaker = new Speaker();
        Megaphone.letMeSpeakConsole(speaker);
        speaker.deallocate();
    }
}
