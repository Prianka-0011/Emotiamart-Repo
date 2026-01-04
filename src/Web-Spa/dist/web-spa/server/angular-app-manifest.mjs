
export default {
  bootstrap: () => import('./main.server.mjs').then(m => m.default),
  inlineCriticalCss: true,
  baseHref: '/',
  locale: undefined,
  routes: [
  {
    "renderMode": 2,
    "route": "/"
  }
],
  entryPointToBrowserMapping: undefined,
  assets: {
    'index.csr.html': {size: 23563, hash: '0820dc11f268da9fd4e4fb2180c3a48ab1580a294dd61df7bb2e379fb9c85953', text: () => import('./assets-chunks/index_csr_html.mjs').then(m => m.default)},
    'index.server.html': {size: 17137, hash: '56b5563b836ca9e999789f37a9dbd158613203735d85a350a2dae36f25026b89', text: () => import('./assets-chunks/index_server_html.mjs').then(m => m.default)},
    'index.html': {size: 23795, hash: 'd0e9e582ff69ed568696d6e4a2d06aa5fde6dab54b9e3dc9954e70b267f3ab75', text: () => import('./assets-chunks/index_html.mjs').then(m => m.default)},
    'styles-LR4OKDNK.css': {size: 12511, hash: '+JTuowRxfk4', text: () => import('./assets-chunks/styles-LR4OKDNK_css.mjs').then(m => m.default)}
  },
};
