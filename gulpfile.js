/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

/// <binding Clean='clean' />
"use strict";

var paths = {
    webroot: './wwwroot/'
};

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  fs = require("fs"),
  less = require("gulp-less"),
  sass = require('gulp-ruby-sass'),
  uncss = require('gulp-uncss');


gulp.task('default', () => {
    sass('Styles/application.scss')
        .on('error', sass.logError)
        .pipe(gulp.dest(paths.webroot + '/dist'));
});

gulp.task('uncss', () => {
    return gulp.src('wwwroot/dist/application.css')
    .pipe(uncss({
        html: ['http://localhost:1400']
    }))
    .pipe(gulp.dest(paths.webroot + '/uncss'));
})