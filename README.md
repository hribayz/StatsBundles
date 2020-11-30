# StatsBundles

Sometimes an algorithm that calculates a function of one-dimensional input yields useful statistics as by-products.
When this by-product is a necessary step of the algorithm, having it for free does not violate the Single Responsibility principle.
An example of this is the Welfords Algorithm which calculates Variance in one pass and yields Mean as a by-product.

This library provides an interface for implementation of any algorithm that yields one or more numeric outputs on one-dimensional numeric input.
It is Typed by the desired data bundle output to indicate which statistics should be calculated alongside using some efficient algorithm.
