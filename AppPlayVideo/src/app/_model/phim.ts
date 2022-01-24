export class Phim {
  public PHIMID: string = '';
  public TENPHIM: string = '';
  public MOTA: string = '';
  public URL: string = '';
  public URLSUBTITLE: string = '';
  constructor(init?: Partial<Phim>) {
    Object.assign(this, init);
  }
}
