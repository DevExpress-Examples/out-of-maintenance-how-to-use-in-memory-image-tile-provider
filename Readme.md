<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/InMemoryTileProvider/Form1.cs) (VB: [Form1.vb](./VB/InMemoryTileProvider/Form1.vb))**
<!-- default file list end -->
# How to implement an in-memory image tile provider in the Map Control

This example illustrates how to generate image tiles at runtime.

<h3>Description</h3>

To do this, attach a custom tile generator class implementing the 
**IImageTileSource** interface to the **ImageTileDataProvider.TileSource** property.
