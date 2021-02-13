import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-paiging-header',
  templateUrl: './paiging-header.component.html',
  styleUrls: ['./paiging-header.component.scss']
})
export class PaigingHeaderComponent implements OnInit {

  @Input() pageSize: number;
  @Input() pageNumber: number;
  @Input() totalCount: number;
  constructor() { }

  ngOnInit() {
  }

}
