module.exports = {
  root: true,
  extends: ['eslint:recommended', 'plugin:svelte/recommended'],
  parserOptions: {
    sourceType: 'module',
    ecmaVersion: 2020,
    extraFileExtensions: ['.svelte']
  },
  env: {
    browser: true,
    es2017: true,
    node: true
  },
  rules: {
    'no-unused-vars': [
      1,
      {
        'varsIgnorePattern': '^_',
        'argsIgnorePattern': '^_'
      }
    ],
    eqeqeq: 2,
    'comma-dangle': [2, {
      arrays: 'only-multiline',
      objects: 'only-multiline',
    }],
    'no-console': 0,
    'no-debugger': 1,
    'no-extra-semi': 1,
    'no-extra-parens': 0, //<Ctrl>D automatically adds extra parentheses!
    'no-irregular-whitespace': 0,
    'no-undef': 2,
    semi: 1,
    'semi-spacing': 1,
    'valid-jsdoc': [
      2,
      {
        requireReturn: false,
      },
    ],
    quotes: [2, 'single'],
    'object-curly-newline': [0, {
      minProperties: 10
    }],
    'no-extra-boolean-cast': 0,
  }
};
