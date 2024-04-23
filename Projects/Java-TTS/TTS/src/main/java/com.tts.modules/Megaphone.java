package com.tts.modules;

import java.util.Scanner;

public class Megaphone {
    public static void letMeSpeakConsole(Speaker speaker){
        String text = "";
        Scanner scanner = new Scanner(System.in);
        while(!text.equals("bye")){
            System.out.println("Write that what you want me to speak, if you want to leave, just write 'bye':");
            text = scanner.nextLine();
            speaker.speak(text);
        }
    }
}
