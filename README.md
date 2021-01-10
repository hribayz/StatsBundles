# StatsBundles

Sometimes an algorithm that calculates a function of one-dimensional input can yield useful statistics as by-products. An example of this is the Welfords Algorithm which calculates Variance in one pass and yields Mean as a by-product at no additional cost.

If the algorithm needs it, why not have it for free?

This library provides an interface for implementation of any algorithm that yields one or more numeric outputs on one-dimensional numeric input.
It is Typed by the desired data bundle output to indicate which statistics should be calculated alongside using some efficient algorithm.
