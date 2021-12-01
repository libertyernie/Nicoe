namespace Nicoe.Configuration {
    public interface INintendontConfiguration {
        uint Version { get; }

        bool AUTO_BOOT { get; set; }

        string GamePath { get; set; }
        string CheatPath { get; set; }
        string GameID { get; set; }

        void Load(byte[] data);
        byte[] Export();
    }
}
