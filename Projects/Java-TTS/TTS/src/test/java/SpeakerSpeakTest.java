import com.app.modules.Speaker;
import org.junit.Assert;
import org.junit.jupiter.api.Test;

import java.util.List;

public class SpeakerSpeakTest {
    @Test
    void isTextBlank(){
        Speaker speaker = new Speaker("kevin16");
        Assert.assertEquals(1, speaker.speak("ggg"));
    }
}
