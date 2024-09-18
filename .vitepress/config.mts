import { defineConfig } from 'vitepress'
import {glob} from 'glob'
import path from 'path'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "ICT-323 Fun",
  description: "Module ICT 323 sur la programmation fonctionnelle",
  themeConfig: {
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Home', link: '/' },
      { text: 'Séquences', link: '/sequences' }
    ],

    sidebar: [
      {
        text: 'Séquences',
        collapsed : false,
        items: Array.from({ length: 8 }, (_, i) => ({ text: `sequence ${i+1}`, link: `/sequences/0${i+1}` }))
      },
      {
        text: 'Supports',
        collapsed : true,
        items: glob.sync('supports/**/*.md')
          .map(f => '/' + f)
          .map((file) => ({ text: `${path.basename(file)}`, link: `${file}` })).reverse()
      }
      ,
      //todo : dynamic
      {
        text: 'Exos',
        collapsed : true,
        items: 
        [
          { text: "marché", link: "/exos/marché/enoncé" },
          { text: "filter1", link: "/exos/filter1/" },
          { text: "market-is-back", link: "/exos/market-is-back/" },
          { text: "rando", link: "/exos/rando/" },
          { text: "silkroad", link: "/exos/silkroad/" },
        ]
      }
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/ETML-INF' }
    ],
    search: {
      provider: 'local'
    }
  },
  ignoreDeadLinks: true,
  base: "/{REPO}/",//for gh pages
  
  rewrites: {
    'README.md': 'index.md',
    '(.*)/README.md': '(.*)/index.md'
  },
  //disable next/previous
  transformPageData(pageData) {
    //pageData.frontmatter.next ??= false;
    pageData.frontmatter.previous ??= false;
  }
})
