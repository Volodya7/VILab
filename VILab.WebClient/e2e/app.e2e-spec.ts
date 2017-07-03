import { ViLab.WebSitePage } from './app.po';

describe('vi-lab.web-site App', () => {
  let page: ViLab.WebSitePage;

  beforeEach(() => {
    page = new ViLab.WebSitePage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
