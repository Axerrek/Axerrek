package com.app.modules;

import com.app.console.Console;
import com.app.gui.Gui;
import com.sun.speech.freetts.Voice;
import com.sun.speech.freetts.VoiceManager;
import org.apache.commons.cli.CommandLine;
import org.apache.commons.cli.ParseException;

import javax.swing.*;
import java.util.Scanner;

public class Speaker {
    public Voice voice;

    public void setVoice(String string) {
        voice = VoiceManager.getInstance().getVoice(string);
        voice.allocate();
    }

    private void setVoiceConsole(){
        do {
            try{
                System.out.println("Choose the voice from the list below:");
                int tmp;
                Voice []voicelist = VoiceManager.getInstance().getVoices();
                for (int i=0; i<voicelist.length; i++) {
                    System.out.println("# Voice "+i+": " + voicelist[i].getName());
                }
                Scanner scanner = new Scanner(System.in);
                System.out.println("Write an integer which matches your chosen voice:");
                tmp = scanner.nextInt();
                setVoice(voicelist[tmp%voicelist.length].getName());
                break;
            }
            catch(Exception e){
                System.out.println("You have to write an integer number!!!");
            }
        }while(true);


    }

    private void setVoiceGui(JTextArea text, JComboBox<String> list, JButton button){
        text.setText("Choose the voice from the list below");
        Voice []voicelist = VoiceManager.getInstance().getVoices();
        for (Voice value : voicelist) {
            list.addItem(value.getName());
        }
    }
    public Speaker(){
        System.setProperty("freetts.voices", "com.sun.speech.freetts.en.us.cmu_us_kal.KevinVoiceDirectory");
        setVoiceConsole();
    }

    public Speaker(String string){
        System.setProperty("freetts.voices", "com.sun.speech.freetts.en.us.cmu_us_kal.KevinVoiceDirectory");
        setVoice(string);
    }

    public Speaker(JTextArea text, JComboBox<String> list, JButton button){
        System.setProperty("freetts.voices", "com.sun.speech.freetts.en.us.cmu_us_kal.KevinVoiceDirectory");
        setVoiceGui(text, list, button);
    }

    public int speak(String string){
        if(string.isEmpty()) return 0;
        voice.speak(string);
        return 1;
    }

    public void deallocate(){
        voice.deallocate();
    }

}
