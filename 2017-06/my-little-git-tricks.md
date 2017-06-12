# my little git tricks

**I added a new `Develop` branch in Visual Studio and the remote cannot see it.** From the command line push upstream with the `-u` switch:

```bash

git push -u origin Develop

```

For detail, see [the StackOverflow post](https://stackoverflow.com/questions/2765421/how-do-i-push-a-new-local-branch-to-a-remote-git-repository-and-track-it-too).

**I need to merge `master` with `Develop`**:

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

For detail, see [the StackOverflow answer](https://stackoverflow.com/a/29048781/22944).

**I added a Develop branch on the remote web client but my local repository cannot see it.** I need to `fetch` the remote repository:

```bash

git ls-remote origin

git fetch

git branch -a

```

**I want to add and commit in one command.** According to [gitref.org](http://gitref.org/basic/), “If you think the git add stage of the workflow is too cumbersome, Git allows you to skip that part with the `-a` option. This basically tells Git to run git add on any file that is ‘tracked’—that is, any file that was in your last commit and has been modified.”:

```bash

git commit -m "changes to hello file"

```

**I forgot to git-ignore folder `foo` and I need to delete it from the remote repository.** This is done with `git rm`:

```bash

git rm -r --cached ~/foo

```