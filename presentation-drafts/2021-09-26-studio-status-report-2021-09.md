---json
{
  "documentId": 0,
  "title": "studio status report: 2021-09",
  "documentShortName": "2021-09-26-studio-status-report-2021-09",
  "fileName": "index.html",
  "path": "./entry/2021-09-26-studio-status-report-2021-09",
  "date": "2021-09-26T18:30:21.532Z",
  "modificationDate": "2021-09-26T18:30:21.532Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-09-26-studio-status-report-2021-09",
  "tag": "{\r\n  \"extract\": \"\"\r\n}"
}
---

# studio status report: 2021-09

## month 09 of 2021 was about restoring kintespace.com hits data collection and other Studio chores

The day job is kicking my ass. Period.

My Studio work is broken up into small fragments as my large projects suffer neglect:

- kintespace.com: salvaging hits for month 8
- [my F# education](https://github.com/BryanWilhite/jupyter-central/tree/master/get-programming-with-f-sharp) continues
- Azure DevOps can support Jupyter notebooks with [a renderer](https://marketplace.visualstudio.com/items?itemName=ms-air-aiagility.ipynb-renderer)
- Azure DevOps can support Mermaid `*mmd` files with [a renderer](https://marketplace.visualstudio.com/items?itemName=xinyi-joffre.mermaid-renderer)
- my first [Oh My Bash](https://github.com/ohmybash/oh-my-bash) installation clobbered by `.bashrc` file and `conda` stuff is still broken
- JetBrains Rider cannot save Markdown settings [[opened issue](https://youtrack.jetbrains.com/issue/RIDER-67953?clearDraft=true&description=Version:%20RD-212.4746.113Timezone:%20America%2FLos_AngelesEvaluation:%20falseEnvironment:%20RD-212.4746.113,%20JRE%2011.0.11%209-b1504.13x64%20JetBrains%20s.r.o.,%20OS%20Linux(amd64)%20v5.11.0-34-generic,%20screens%202400.0x1350.0.NET%205.0.7&c=Affected%20versions%202021.2%20(212.4746.113))]
- an aging `ts-mocha` is holding back ‘everything’
- i am running Mathematica from Linux for the first time!

The biggest news under this mess is the progress in thinking about a Songhay _Timed-Text Motion Graphics_ Player. Ideally, more on this later.

### kintespace.com: salvaging hits for month 8

```bash
cat \
    access.log.14 \
    access.log.13 \
    access.log.12 \
    access.log.11 \
    access.log.10 \
    access.log.9 \
    access.log.8 \
    access.log.7 \
    access.log.6 \
    access.log.5 \
    access.log.4 \
    access.log.3 \
    access.log.2 \
    access.log.1 > access.log
```

Extract `kintespace.com-2021-08.log` from archive and rename to `kintespace.com-2021-08-incomplete.log`.

```bash
cat access.log kintespace.com-2021-08-incomplete.log > kintespace.com-2021-08.log
```

```bash
tar -czf kintespace.com-2021-08.log.gz kintespace.com-2021-08.log
```

<https://www.howtogeek.com/278599/how-to-combine-text-files-using-the-cat-command-in-linux/>

### an aging `ts-mocha` is holding back ‘everything’

…and `ts-lint` too…

The packages other than `ts-mocha` and `ts-lint` cannot be upgraded because of requirements of these two aging packages:

```json
"devDependencies": {
    "@types/chai": "^4.2.14",
    "@types/chai-spies": "^1.0.3",
    "@types/expect": "^24.3.0",
    "@types/mocha": "^8.2.0",
    "chai": "^4.2.0",
    "chai-spies": "1.0.0",
    "es-dev-server": "^2.1.0",
    "lerna": "^4.0.0",
    "mocha": "^8.2.1",
    "ts-mocha": "^8.0.0",
    "tslint": "^6.1.3",
    "typedoc": "^0.19.2",
    "typescript": ">=3.0.0 <3.9.7"
}
```

There might be a way to use Typescript with `mocha` without needing `ts-mocha`.

## 

## sketching out a development schedule (revision 18)

The schedule of the month:

- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- build Web components required for new version of SonghaySystem.com 🖼
- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com ✅
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- modernize the kinté hits page into a progressive web app 💄✨
- use the learnings of previous work to upgrade and re-release the kinté space 🚀
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

@[BryanWilhite](https://twitter.com/BryanWilhite)
