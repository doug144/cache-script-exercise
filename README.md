# Cache Script Excercise
The sample application from this repository uses caching attributes that allow for dynamic configuration of the cache: Redis, in-memory, etc.
The problem with such a solution is that if the cache is not properly configured, the code will compile, but in runtime no caching will take place.
## Assumptions
### The CI/CD Pipeline
For the sake of the exercise, we will assume that the pipeline looks like this:
![Flow](Flow.png)

When code is pushed, the build is triggered automatically and outputs an artifact. The deployment pipeline then takes the artifact and deploys it to each relevant environment.
**The build pipeline and deployment pipeline are completely separate** and share no tasks/variables/etc.

### Cache Configuration
A REST endpoint **already exists** to verify that a cache is configured for a given service:
GET http://myconfigurationservice.com/{ServiceName}/Cache?name={CacheName}

You can assume that the endpoint returns HTTP 200 when a cache is properly configured and HTTP 404 when it is not configured.

### Cache Code
The configurable cache is applied in the code as shown below:
```csharp
[Cache("CacheName")]
public object Foo(string param1)
{
    ...
}
```
You can find usage of this `[Cache]` attribute in numerous places in the code (i.e. in [HashCodeCalulator.cs](/ClassLibrary/HashCodeCalulator.cs)).


## Your task
You need create a solution that will avoid deploying code that contains caches that are not configured. Adjustments can be made anywhere in the [CI/CD Pipeline](#ci/cd-pipeline), 
but not in the code itself.

Your solution should be submitted by email and should include:
1. A text file describing the overall solution
1. Implementation of any required scripts in the scripting language of your choice