
# Shadron-GIF extension

This is an official extension for [Shadron](http://www.shadron.info/)
which adds the functionality to load and export animated GIF files via
[GIFLIB](http://giflib.sourceforge.net/) and [libimagequant](https://pngquant.org/lib/).

### List of features
 - `gif_file` animation object, which loads animated GIF files
 - animated GIF file export
 - image color quantization

## Installation

Place `shadron-gif.dll`
in the `extensions` directory next to Shadron's executable, or better yet,
in `%APPDATA%\Shadron\extensions`. It will be automatically detected by Shadron on next launch.
Requires Shadron 1.1.3 or later.

## Usage

Before using any objects specific to this extension, it must first be enabled with the following directive:

    #extension gif

Create an input GIF animation with:

    animation InputAnimation = gif_file("filename.gif");

(The file name specification is optional just like in the `file` initializer.)

To export an animation as a GIF file, you may declare a GIF export like this:

    export gif(MyAnimation, "output.gif", <framerate>, <duration>, <repeat>);

The framerate (frames per second) and duration (seconds) parameters are the same
as in `png_sequence` and other export types.
The repeat parameter (true / false) is optional and sets whether the GIF file
should repeat.

You may also apply the color quantization algorithm used for the GIF export
on an image or animation like this:

    image QuantizedImage = quantize(SourceImage, <color count>);
    animation QuantizedAnimation = quantize(SourceAnimation, <color count>);

The color count may be parametrized, but must be between 2 and 256.
