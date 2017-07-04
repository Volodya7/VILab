import { ViLabWebClientPage } from './app.po';

describe('vi-lab-web-client App', () => {
  let page: ViLabWebClientPage;

  beforeEach(() => {
    page = new ViLabWebClientPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
