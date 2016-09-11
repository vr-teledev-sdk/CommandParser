package com.tele.vr.sdk.testplugin;
import java.util.Set;

/**
 * @author korolyov
 *         05.09.16
 */
public class TelegramCommand {
    private Set<String> aliases;
    private String command;
    private TelegramCommandParams params;

    public TelegramCommand(Set<String> aliases, String command, TelegramCommandParams params) {
        this.aliases = aliases;
        this.command = command;
        this.params = params;
    }

    public boolean commandForALias(String alias) {
        if (aliases.isEmpty() || aliases.contains(alias)) {
            return true;
        } else {
            return false;
        }
    }


    public String getCommand() {
        return command;
    }

    public TelegramCommandParams getParams() {
        return params;
    }

    @Override
    public String toString() {
        return "TelegramCommand{" +
            "aliases=" + aliases +
            ", command='" + command + '\'' +
            ", params=" + params +
            '}';
    }
}
