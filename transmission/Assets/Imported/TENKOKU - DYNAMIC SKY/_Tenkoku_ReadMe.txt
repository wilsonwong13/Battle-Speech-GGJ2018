---------------------------------------------------
TENKOKU - DYNAMIC SKY

Copyright ©2017 Tanuki Digital
Version 1.1.5
---------------------------------------------------


----------------------------
THANK YOU FOR YOUR PURCHASE!
----------------------------
Thank you for buying TENKOKU and supporting Tanuki Digital!
It's people like you that allow us to build and improve our software! 
if you have any questions, comments, or requests for new features
please visit the Tanuki Digital Forums and post your feedback:

http://tanukidigital.com/forum/

or email us directly at: konnichiwa@tanukidigital.com



----------------------
REGISTER YOUR PURCHASE
----------------------
Did you purchase Tenkoku - Dynamic Sky on the Unity Asset Store?
Registering at Tanuki Digital.com gives you immediate access to new downloads, updates, and exclusive content as well as Tenkoku and Tanuki Digital news and info.  Fill out the registration forum using your Asset Store "OR" Order Number here:

http://www.tanukidigital.com/tenkoku/index.php?register=1



----------------------
SUPPORT
----------------------
If you have questions about Tenkoku, need help with a feature, or think you've identified a bug please let us know either in the Unity forum or on the Tanuki Digital forum below.

Unity Forum Thread: http://forum.unity3d.com/threads/tenkoku-dynamic-sky.318166/
Tanuki Digital Forum: http://tanukidigital.com/forum/

You can also email us directly at: konnichiwa@tanukidigital.com



----------------------
DOCUMENTATION
----------------------
Please read the Tenkoku documentation files for more in-depth customization information.
http://tanukidigital.com/tenkoku/documentation



-------------
INSTALLATION
-------------
I. IMPORT TENKOKU FILES INTO YOUR PROJCT
Go to: “Assets -> Import Package -> Custom Package...” in the Unity Menu and select the “tenkoku_dynamicsky_ver1.x.unitypackage” file. This will open an import dialog box. Click the import button and all the Tenkoku files will be imported into your project list.

II. ADD THE TENKOKU MODULE TO YOUR SCENE
1) Drag the Tenkoku DynamicSky prefab located in the “/PREFABS” folder into your scene list.
2) If it isn’t set already, make sure to set the Tenkoku DynamicSky’s position in the transform settings to 0,0,0

III. ADD TENKOKU EFFECTS TO YOUR CAMERA
1) Click on your main camera object and add the Tenkoku Fog effect by going to Component-->Image Effects-->Tenkoku-->Tenkoku Fog.
Note: For best results this effect should be placed to render BEFORE your Tonemapping effect(if applicable).

(optional)
2) Click on your main camera object and add the Tenkoku Sun Shaft effect by going to Component-->Image Effects-->Tenkoku-->Tenkoku Sun Shafts.
Note: For best results this effect should be placed to render AFTER your Tonemapping effect(if applicable).


A Note About Scene Cameras:
Tenkoku relies on tracking your main scene camera in order to properly update in the scene.  By default Tenkoku attempts to auto locate your camera by selecting the camera in your scene with the ‘MainCamera’ tag.  Alternatively you can set it to manual mode and drag the appropriate camera into the ‘Scene Camera’ slot.




-------------
NOTES
-------------
A Note On Accuracy:
Moon and planet position calculations are currently accurate for years ranging between 1900ca - 2100ca.  The further away from the year 2000ca that you get (in either direction) the more noticeable calculation errors will become.  Additional calculation methods are currently being looked at to increase the accuracy range for these objects.




-------------------------------
RELEASE NOTES - Version 1.1.5
-------------------------------

BUG FIXES (1.1.5e)
- Fixed Scattering shader which was preventing proper color rendering in DX9 and MacOSX.
- Adjusted Dusk/Dawn lighting to be less red.
- Fixed bug showing incongruous horizon line when during overcast weather.
- Fixed issue with y-reversal in fog buffer when using Forward and MSAA.
- Changed rain/snow/fog particle collisions to 'default' Unity layer.  Should help with default performance.

BUG FIXES (1.1.5d)
- Fixed new sky atmosphere shader to work properly on MacOSX.

BUG FIXES (1.1.5c)
- Fixed fog/sky tracking error while switching scene cameras.

BUG FIXES (1.1.5b)
- Fixed overdarkening of Stratus and Cirrus clouds.


WHAT'S NEW
- New Atmospheric rendering based on Oskar Elek model.  This is set by default.  You can switch back to previous sky model in the 'Atmospherics' section if you prefer. (use in conjunction with Tonempaping is highly recommended).
- Improved Aurora rendering model should give more interesting and realistic looking aurora effects.
- Added tooltips in editor on many settings (hover over the *).  Only works while not in play mode (Unity, doh!)
- Added 'Disable MSAA' setting that forces MSAA off when selected. (On by default)
- Added 'Ambient Source' selection option.  Can now set ambient to 'Skybox' for more realistic Ambient Rendering.
- Added 'Add Automatic FX' option which allows control over automatic camera FX instantiation.
- Added 'Day Ambient Amount' in color section to control ambient multiplier brightness during day (skybox ambient only).
- Added 'Night Ambient Amount' in color section to control ambient multiplier brightness during night (skybox ambient only).
- Night lighting is now modulated properly by the moon phase, so waxing/waning moons will be darker than full moons.
- Added 'Weather Overcast Darkening' slider that separately controls the overcast darkening from the overcast cloud rendering.

CHANGES
- Force disable 'Temporal Aliasing' when running on Mac. Hopefully there will be a mac-compatible version in the future.
- Tenkoku now forces built-in reflection probe intensity to 1.0 for accurate sky color reflections.
- Edited cloud and sun gradients for more realistic behavior around dawn/dusk.
- Edited star visibility transition timing to be more realistic.
- Updated Solar eclipse Flare texture.
- Clock display in 'Time and Position' tab changed to text display (no longer used as time inputs, use sliders instead.)
- Brightened Moon Rendering and improved Day Sky blending.
- Tenkoku_SetTransition() function now accepts floats for time duration. (note: int duration input is marked for removal)
- Tenkoku_SetTransition() now inlcudes Smoothed start/end transition by default.
- Tenkoku_SetTransition() now accepts optional AnimationCurve input to better control transitions.
- Made sun shaft lighting less orange during non dawn/dusk hours.
- Gradient Source set to 'Texture' by default.
- Lowered sun flare intensity.

BUG FIXES
- Fixed camera tracking to use proper world coordinates (was causing distance clipping in clouds/stars/galaxy).
- Cached component lookups to reduce Garbage Collection resources.
- Cloud movement now respects Unity Time.timeScale settings.
- Cloud noise generation no longer freezes if timescale is set to 0.
- Legacy cloud movement now corrected when 'link to system' is off.
- Fixed Sun render clipping when set to larger sizes.
- Set default Sun Mie value to be lower.
- Ambient light is now affected by solar eclipse state.
- Fixed 'Scene light layers' list population bug in editor.
- Fixed bug with Tenkoku_SetTransition() functionality, now should be working properly.
- Moon lighting now fades in at proper time (no more dark areas between sun and moon).
- Moon brightness adjustments in Gamma mode.
- Lightning no longer flashes continuously if factor is changed during lightning strike.









----------------------------
CREDITS
----------------------------
- Cloud System adapted from prototype work by Keijiro Takahashi.  Used with permission.
https://github.com/keijiro

- Temporal Reprojection is modified from Playdead Games' public implementation, available here:
https://github.com/playdeadgames/temporal

- Oskar Elek Atmospheric model originally developed in 2009 by Oskar Elek.  Model has been adapted for Unity by Michal Skalsky (2016) as part of his Public Domain work regarding volumetric atmospheric rendering:
http://www.oskee.wz.cz/stranka/oskee.php
https://github.com/SlightlyMad

- Lunar image adapted from texture work by James Hastings-Trew.  Used with permission.
http://planetpixelemporium.com

- Galaxy image adapted from an open source image made available by the European Southern Observatory(ESO/S. Brunier):
https://www.eso.org/public/usa/images/eso0932a/

- Star position and magnitude data is taken from the Yale Bright Star Catalog, 5th Edition:
http://tdc-www.harvard.edu/catalogs/bsc5.html (archive)
http://heasarc.gsfc.nasa.gov/W3Browse/star-catalog/bsc5p.html (data overview)

- Calculation algorithms for Sun, Moon, and Planet positions have been adapted from work published by Paul Schlyter, in his paper 'Computing Planetary Positions'.  I've taken liberties with his procedure where I thought appropriate or where I found it best suits the greater Tenkoku system.  You can read his original paper here:
http://www.stjarnhimlen.se/comp/ppcomp.html  
