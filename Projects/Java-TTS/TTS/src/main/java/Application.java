import com.app.console.Console;
import com.app.gui.Gui;
import org.apache.commons.cli.*;

public class Application {
    public static void main(String[] args){
        Options options = new Options();
        options.addOption("t", "type", true,"console or gui");

        CommandLineParser parser = new DefaultParser();
        try{
            CommandLine cmd = parser.parse(options,args);
            String appType = cmd.getOptionValue("type");
            if(appType.toLowerCase().equals("console")){
                Console.run();
            }
            else{
                Gui.runGui();
            }
        }
        catch(ParseException e){
            System.out.println("Error: "+ e.getMessage());
        }
    }
}
