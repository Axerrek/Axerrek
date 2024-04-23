package com.tts.modules;

import com.sun.speech.freetts.Voice;
import com.sun.speech.freetts.VoiceManager;

import javax.swing.*;
import java.util.Scanner;

public class Speaker {
    public Voice voice;

    public void setVoice(String string) {
        voice = VoiceManager.getInstance().getVoice(string);
        voice.allocate();
    }

    private void setVoiceConsole(){
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

    public Speaker(JTextArea text, JComboBox<String> list, JButton button){
        System.setProperty("freetts.voices", "com.sun.speech.freetts.en.us.cmu_us_kal.KevinVoiceDirectory");
        setVoiceGui(text, list, button);
    }

    public void speak(String string){
        voice.speak(string);
    }

    public void deallocate(){
        voice.deallocate();
    }

}
