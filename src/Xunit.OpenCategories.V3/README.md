# Xunit.OpenCategories
Friendlier attributes to help categorise your tests.

## Messy Traits?
The xUnit built in option *Traits* can get a little messy. Its just 2 strings representing a key and value, unless you are familiar with xUnit and the Trait attribute it looks a little magical.

Also both key and value must be specified on the command line. This means if you decorate your test with
`[Trait("Category","Bug")]` you cannot run only tests from a specific bug  without adding another trait `([Trait("Bug","8675309"])`

## Links

- [Issues](https://github.com/baynezy/Xunit.OpenCategories/issues)
- [Documentation](https://baynezy.github.io/Xunit.OpenCategories/)