# PlgxUnpacker.NET

A lightweight library for unpacking [KeePass](https://keepass.info/) [PLGX files](https://keepass.info/help/v2_dev/plg_index.html#plgx).

[![NuGet Version (PlgxUnpacker.NET)](https://img.shields.io/nuget/v/PlgxUnpacker.NET.svg)](https://www.nuget.org/packages/PlgxUnpacker.NET/)
[![MIT License](https://img.shields.io/github/license/cristianst85/PlgxUnpacker.NET.svg)](https://github.com/cristianst85/PlgxUnpacker.NET/blob/master/LICENSE)

## Usage

```C#
if (PlgxFile.IsPlgxFile(filePath))
{
	var plgxFile = PlgxFile.LoadFromFile(filePath);
	plgxFile.UnpackTo(directoryPath);
}
```

## Repository

The main repository is hosted on [GitHub](https://github.com/cristianst85/PlgxUnpacker.NET).

## Changelog

See [CHANGELOG](https://github.com/cristianst85/PlgxUnpacker.NET/blob/master/CHANGELOG.md) file for details.

## License

PlgxUnpacker is released under the MIT License. See the [bundled LICENSE](https://github.com/cristianst85/PlgxUnpacker.NET/blob/master/LICENSE) file for details.

## Credits

The idea for this library was inspired by [PlgxExtractor](https://github.com/Geograph-us/PlgxExtractor).

## Related Projects

* [PlgxUnpacker.Tools](https://github.com/cristianst85/PlgxUnpacker.Tools)
