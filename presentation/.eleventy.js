module.exports = function (config) {
    config.addCollection('entries', collection => {
        return collection.getFilteredByGlob('entry/**/*.md');
    });

    config.addFilter('blogHead', (collection, n) => {
        const array = collection.sort((a, b) => {
            return b.date - a.date;
        });

        return array.slice(0, n);
    });

    config.addFilter('getExtract', (tag) => {
        const jTag = JSON.parse(tag);
        return jTag.extract;
    });

    return {
        dir: {
            input: '.',
            output: '../../day-path/app',
            includes: 'templates'
        },
        htmlTemplateEngine: 'liquid',
        markdownTemplateEngine: 'liquid',
        templateFormats: ['html', 'md', 'liquid']
    };
};
