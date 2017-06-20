import { BeheerdersportaalPage } from './app.po';

describe('beheerdersportaal App', () => {
  let page: BeheerdersportaalPage;

  beforeEach(() => {
    page = new BeheerdersportaalPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
