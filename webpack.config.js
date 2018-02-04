'use strict';

const path = require('path');

module.exports = {
    entry: {
        app: './content/js/app.js',

    },
    output: {
        path: path.resolve(__dirname, './wwwroot/js'),
        filename: '[name].js',
        chunkFilename: "[id].js",
        publicPath: '/js/',
        library: '_',
    },
    module: {
        rules: [{
                test: /\.(js)$/,
                exclude: /node_modules/,
                loader: 'babel-loader',
                query: {
                    presets: ['es2015'],
                }
            }, {
                test: /\.(scss)$/,
                use: [{
                    loader: 'style-loader', // inject CSS to page
                }, {
                    loader: 'css-loader', // translates CSS into CommonJS modules
                    options: {
                        sourceMap: true
                    }
                }, {
                    loader: 'postcss-loader', // Run post css actions
                    options: {
                        plugins: function() { // post css plugins, can be exported to postcss.config.js
                            return [
                                require('precss'),
                                require('autoprefixer')
                            ];
                        }
                    }
                }, {
                    loader: 'sass-loader', // compiles Sass to CSS
                    options: {
                        includePaths: ["content/scss"],
                        sourceMap: true
                    }
                }]
            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            },
            {
                test: /\.vue$/,
                use: ['vue-loader']
            }, {

                test: /\.(png|jpg|jpeg|gif|eot|ttf|woff|woff2|svg|svgz)(\?.+)?$/,

                use: [{

                    loader: 'url-loader',

                    options: {

                        limit: 10000

                    }

                }]

            }
        ]
    },
    resolve: {
        extensions: ['.js'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        }
    },
    devtool: 'source-map',
    plugins: [],
    watch: true
};