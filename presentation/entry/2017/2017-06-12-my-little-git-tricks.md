---json
{
  "documentId": 0,
  "title": "my little git tricks",
  "documentShortName": "2017-06-12-my-little-git-tricks",
  "fileName": "index.html",
  "path": "./entry/2017-06-12-my-little-git-tricks",
  "date": "2017-06-12T21:23:14.566Z",
  "modificationDate": "2017-06-12T21:23:14.566Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2017-06-12-my-little-git-tricks",
  "tag": "{\r\n  \"extract\": \"The title of this post is trying to tell you that I am not a git expert. These are my cross-platform notes for the subset of git I’ve needed to use so far:I added a new Develop branch in Visual Studio and the remote cannot see it. From the command line p...\"\r\n}"
}
---

# my little git tricks

The title of this post is trying to tell you that I am *not* a git expert. These are my cross-platform notes for the subset of git I’ve needed to use so far:

**I added a new `Develop` branch in Visual Studio and the remote cannot see it.** From the command line push upstream with the `-u` switch:

<code class="lang-bash">
git push -u origin Develop
<
/code>

For detail, see [the StackOverflow post](https://stackoverflow.com/questions/2765421/how-do-i-push-a-new-local-branch-to-a-remote-git-repository-and-track-it-too). And recall that the `-u` or `--set-upstream` sets the origin for the argument-less `git pull` command—which means that you should only use the `-u` option only once.

**I need to merge `master` with `Develop`.** What’s important to remember in this scenario is the fundamental concept of git: your local repository is a clone of the remote. This means that a merge operation occurs between branches on your local machine. This explains why you need to checkout and pull from the source branch of the merge:

<code class="lang-bash">
git checkout Develop
git pull
git checkout master
git pull
git merge --no-ff --no-commit Develop

git status

git commit -m "merging with Develop branch"

git push
<
/code>

For detail, see [the StackOverflow answer](https://stackoverflow.com/a/29048781/22944). These commands also arise in the context of responding to a pull request. [Recall that](https://stackoverflow.com/questions/7200614/how-to-merge-remote-master-to-local-branch)`git pull` is basically the same as `git fetch; git merge origin/master`.

**I added a Develop branch on the remote web client but my local repository cannot see it.** I need to `fetch` the remote repository:

<code class="lang-bash">
git ls-remote origin

git fetch

git branch -a
<
/code>

**I forgot to git-ignore folder `foo` and I need to delete it from the remote repository.** This is done with `git rm`:

<code class="lang-bash">
git rm -r --cached ~/foo
<
/code>

**I need to know the status of the remote server.** When `git status` returns, “Your branch is up-to-date,” but you are not sure this is accurate, I should try:

<code class="lang-bash">
git remote update
git status
<
/code>

@[BryanWilhite](https://twitter.com/BryanWilhite)
