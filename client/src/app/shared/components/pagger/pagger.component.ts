import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-pagger',
  templateUrl: './pagger.component.html',
  styleUrls: ['./pagger.component.scss']
})
export class PaggerComponent implements OnInit {

  @Input() totalCount: number;
  @Input() pageSize: number;
  @Output() pageChanges = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  onPaggerChange(event: any) {

    this.pageChanges.emit(event.page);
  }

}
