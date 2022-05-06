# AAXHash
A fast and simple wrapper for retrieving AAX activation bytes.
Retrieves AAX activation bytes using [audible-converter](https://audible-converter.ml).
Usage:
```bash
var d = new AAXHash.Data();
d.Reverse(@"C:\aaxFile.aax");
stringbytes = d.bytes;
```

#### Requirements: .NET 6.0, x64. Feel free to change the required runtime and/or architecture, the current build is just my preference.
