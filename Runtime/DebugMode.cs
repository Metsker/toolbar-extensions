namespace ToolbarExtensions
{
    /// <summary>
    /// Only available in Editor
    /// </summary>
    public static class DebugMode
    {
        private static bool _enabled;

        public static bool Enabled {
            get
            {
#if UNITY_EDITOR
                return _enabled;
#else
                return false;
#endif
            }
            set
            {
#if UNITY_EDITOR
                _enabled = value;
#else
                return;
#endif
            }
        }
    }
}
