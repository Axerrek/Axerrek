import com.tts.modules.Megaphone;
import com.tts.modules.Speaker;

public class Console {


    public static void main(String[] args) {

        Speaker speaker = new Speaker();
        Megaphone.letMeSpeakConsole(speaker);
        speaker.deallocate();
    }
}
