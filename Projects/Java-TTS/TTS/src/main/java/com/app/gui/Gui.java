package com.app.gui;

import com.app.modules.Speaker;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Gui extends JFrame {
    private JTextArea textArea;
    private JButton playButton;
    private JButton setVoiceButton;

    private String tts;
    private JComboBox<String> voiceComboBox;

    private Speaker speaker;

    public Gui() {
        super("ttsGUI");
        textArea = new JTextArea(5, 30);
        textArea.setLineWrap(true);
        textArea.setWrapStyleWord(true);
        textArea.setFont(new Font("Arial", Font.PLAIN, 16));
        playButton = new JButton("Odtwórz tekst");
        setVoiceButton = new JButton("Wybierz głos");
        voiceComboBox = new JComboBox<>();
        playButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                tts = textArea.getText();
                speaker.speak(tts);
            }
        });

        setVoiceButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                textArea.setText("");
                speaker.setVoice(voiceComboBox.getSelectedItem().toString());
                setVoiceButton.setVisible(false);
                playButton.setVisible(true);
            }
        });
        setLayout(null);
        textArea.setBounds(10, 10, 760, 240);
        playButton.setBounds(300, 270, 200, 30);
        setVoiceButton.setBounds(300, 270, 200, 30);
        voiceComboBox.setBounds(10, 270, 150, 30);
        add(voiceComboBox);
        add(setVoiceButton);
        add(textArea);
        add(playButton);

        setResizable(false);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(800, 400);
        setLocationRelativeTo(null);
        setVisible(true);
        playButton.setVisible(false);
        setVoice();
    }

    private void setVoice(){
        speaker = new Speaker(textArea, voiceComboBox, setVoiceButton);
        playButton.setVisible(true);
    }

    public static void runGui() {
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                new Gui();
            }
        });
    }
}
