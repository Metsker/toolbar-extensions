# Toolbar Extensions
<img width="1908" height="45" alt="image" src="https://github.com/user-attachments/assets/86bc9fac-d0e7-4c38-82dd-d335de07e8ec" />

Scene navigation and debug utils for unity toolbar

## Dependencies
This package depends on [unity-toolbar-extender-ui-toolkit](https://github.com/Sammmte/unity-toolbar-extender-ui-toolkit). Since Unity does not support git dependencies for packages, you'll need to install it separately.

## Features:
- Easy navigation between the scenes in build, hold alt to load in additive mode [Buttons]
- Redirect to the first scene in build on play mode enter [Toggle]
- Debug (Works only in Development build and Editor) [Toggle]
- Time scale [Slider]
- Toggle any of the above modules visibility via Tools/Metsker/ToolbarUtils

## Debug mode API usage example:
```
using ToolbarExtensions;

public class Example
{
    void Foo()
    {
        if(DebugMode.Enabled)
        {
            //debug logic
        }
        else
        {
            //release logic
        }
    }
}
```

