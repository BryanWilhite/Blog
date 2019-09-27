---json
{
  "author": "@BryanWilhite",
  "content": "The title of this post is trying to tell you that I am not a git expert. These are my cross-platform notes for the subset of git I’ve needed to use so far:I added a new Develop branch in Visual Studio and the remote cannot see it. From the command line p...",
  "inceptDate": "2017-06-12T14:23:14.5663248-07:00",
  "isPublished": true,
  "itemCategory": "\"year\":2017,\"month\":\"06\",\"day\":\"12\",\"dateGroup\":\"2017\\/06\",\"topic-enterprise-visual-studio\":\"Enterprise Solutions: Visual Studio\"",
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "2017-06-12-my-little-git-tricks",
  "sortOrdinal": 0,
  "tag": null,
  "title": "my little git tricks"
}
---

# my little git tricks

The title of this post is trying to tell you that I am _not_ a git expert. These are my cross-platform notes for the subset of git I’ve needed to use so far:

**I added a new `Develop` branch in Visual Studio and the remote cannot see it.** From the command line push upstream with the `-u` switch:

```bash

git push -u origin Develop

```

For detail, see [the StackOverflow post](https://stackoverflow.com/questions/2765421/how-do-i-push-a-new-local-branch-to-a-remote-git-repository-and-track-it-too). And recall that the `-u` or `--set-upstream` sets the origin for the argument-less `git pull` command—which means that you should only use the `-u` option only once.

**I need to merge `master` with `Develop`.** What’s important to remember in this scenario is the fundamental concept of git: your local repository is a clone of the remote. This means that a merge operation occurs between branches on your local machine. This explains why you need to checkout and pull from the source branch of the merge:

```bash

git checkout Develop
git pull
git checkout master
git pull
git merge --no-ff --no-commit Develop

git status

git commit -m "merging with Develop branch"

git push

```

For detail, see [the StackOverflow answer](https://stackoverflow.com/a/29048781/22944). These commands also arise in the context of responding to a pull request. [Recall that](https://stackoverflow.com/questions/7200614/how-to-merge-remote-master-to-local-branch) `git pull` is basically the same as `git fetch; git merge origin/master`.

**I added a Develop branch on the remote web client but my local repository cannot see it.** I need to `fetch` the remote repository:

```bash

git ls-remote origin

git fetch

git branch -a

```

**I forgot to git-ignore folder `foo` and I need to delete it from the remote repository.** This is done with `git rm`:

```bash

git rm -r --cached ~/foo

```

**I need to know the status of the remote server.** When `git status` returns, “Your branch is up-to-date,” but you are not sure this is accurate, I should try:

```bash

git remote update
git status

```
