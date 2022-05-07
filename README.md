# AAXHash
A fast and simple wrappe/client for retrieving AAX activation bytes.
Retrieves AAX activation bytes using [audible-converter](https://audible-converter.ml).
Usage:
```bash
var h = new AAXHash.Data();
h.Reverse(@"C:\aaxFile.aax");
string bytes = h.bytes;
```

#### Requirements: .NET 6.0, x64. Feel free to change the required runtime and/or architecture, the current build is just my preference.
