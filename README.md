TestDataFactory
===============

Library for effortless generation of (not only) POCO objects.

Short example of usage
======================

	var factory = new TestDataFactory();

    var collection = factory.CreateMany<Entity>(100)
        .FillProperty(x => x.Name).WithValues(x => factory.Noun.GetRandom())
        .FillProperty(x => x.CreationDate).WithValues(new DateTime(2000, 1, 2), new DateTime(2001, 2, 3))
        .Go().ToList();

    Assert.AreEqual(100, collection.Count);

    Assert.IsNotNullOrEmpty(collection[0].Name); // please, pay attention to indexes - values were cycled
    Assert.IsNotNullOrEmpty(collection[2].Name);

    Assert.AreEqual(new DateTime(2000, 1, 2), collection[0].CreationDate); // please, pay attention to indexes - values were cycled
    Assert.AreEqual(new DateTime(2000, 1, 2), collection[2].CreationDate);
    
License
=======

The MIT License (MIT)
Copyright (c) 2012 Constantin Titarenko

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
