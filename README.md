# PlgxUnpacker

A lightweight library for unpacking [KeePass](https://keepass.info/) [PLGX files](https://keepass.info/help/v2_dev/plg_index.html#plgx).

[![NuGet Version (PlgxUnpacker)](https://img.shields.io/nuget/v/PlgxUnpacker.svg)](https://www.nuget.org/packages/PlgxUnpacker/)
[![MIT License](https://img.shields.io/github/license/cristianst85/PlgxUnpacker.svg)](https://github.com/cristianst85/PlgxUnpacker/blob/master/LICENSE)

## Usage

```C#
if (PlgxFile.IsPlgxFile(filePath))
{
	var plgxFile = PlgxFile.LoadFromFile(filePath);
	plgxFile.UnpackTo(directoryPath);
}
```

## Repository

The main repository is hosted on [GitHub](https://github.com/cristianst85/PlgxUnpacker).

## Changelog

See [CHANGELOG](https://github.com/cristianst85/PlgxUnpacker/blob/master/CHANGELOG.md) file for details.

## License

PlgxUnpacker is released under the MIT License. See the [bundled LICENSE](https://github.com/cristianst85/PlgxUnpacker/blob/master/LICENSE) file for details.

## Credits

The idea for this library was inspired by [PlgxExtractor](https://github.com/Geograph-us/PlgxExtractor).

## Related Projects

* [PlgxUnpacker.Tools](https://github.com/cristianst85/PlgxUnpacker.Tools)
