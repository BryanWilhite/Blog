const moment = require('moment');
const UpgradeHelper = require("@11ty/eleventy-upgrade-help");

module.exports = function (config) {
    config.addPlugin(UpgradeHelper);

    config.addCollection('entries', collection => {
        return collection.getFilteredByGlob('entry/**/*.md');
    });

    config.addFilter('blogHead', (collection, n) => {
        const array = collection.sort((a, b) => {
            return b.date - a.date;
        });

        return array.slice(0, n);
    });

    config.addFilter('formatEntryUri', (uri) => {
        const forwardSlash = '/';
        const a = uri.split(forwardSlash);
        return a.filter(i => (i && (i.length > 0))).join(forwardSlash);
    });

    config.addFilter('getExtract', (tag) => {
        const jTag = JSON.parse(tag);
        return jTag.extract;
    });

    config.addFilter('getRfc822Date', (date) => {
        // 📖 https://gist.github.com/tleen/5109955
        const rfc822Date = moment(date).format('ddd, DD MMM YYYY HH:mm:ss ZZ');
        return rfc822Date;
    });

    config.setDataDeepMerge(false);
    config.setLiquidOptions({ dynamicPartials: false, strictFilters: false });

    return {
        dir: {
            data: '_data',
            includes: 'templates',
            input: '.',
            output: '../../day-path/app',
        },
        htmlTemplateEngine: 'liquid',
        markdownTemplateEngine: 'liquid',
        templateFormats: ['html', 'md', 'liquid', 'png']
    };
};
