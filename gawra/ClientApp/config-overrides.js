const {
  addDecoratorsLegacy,
  override,
  disableEsLint,
  addLessLoader,
  addWebpackAlias,
} = require("customize-cra");

const path = require("path");

module.exports = override(
  addDecoratorsLegacy(),
  disableEsLint(),
  addWebpackAlias({
    utils: path.resolve(__dirname, "src/utils"),
    src: path.resolve(__dirname, "src"),
  }),
  addLessLoader({
    lessOptions: {
      javascriptEnabled: true,
      modifyVars: {},
    },
  })
);
