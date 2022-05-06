# AAXHash
A fast and simple wrapper for retrieving AAX activation bytes.
A very simple wrapper for retrieving AAX activation bytes using [audible-converter](https://audible-converter.ml).
Usage:
```bash
var d = new AAXHash.Data();
d.Reverse(@"C:\aaxFile.aax");
stringbytes = d.bytes;```
