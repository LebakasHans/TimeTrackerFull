//  lines to be able to use clientside code like localStorage
export const ssr = false;
export const csr = true;
export const prerender = true;

// make linq available in the whole project
//Note: for production build also import it in the root +page.svelte in case of problems
import '$lib/polyfills/linq.polyfill.js';
