import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { switchMap, takeUntil, tap } from 'rxjs/operators';
import { Player } from '../player';
import { PlayerService } from '../player.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnDestroy, OnInit {
  private readonly _destroyed: Subject<void> = new Subject();
  public readonly players$: Observable<Player[]> = this._playerService.get();    
  public readonly playerSelectControl: FormControl = new FormControl();  
  public readonly playerForm: FormGroup = new FormGroup({
    name: new FormControl("", []),
    description: new FormControl("",[])
  });

  constructor(
    private readonly _playerService: PlayerService
  ) {  }

  ngOnInit(): void {
    this.playerSelectControl.valueChanges
    .pipe(
      takeUntil(this._destroyed),
      switchMap(playerId => this._playerService.getById({ playerId })),
      tap(player => this.playerForm.patchValue(player))
    ).subscribe();
  }

  ngOnDestroy() {
    this._destroyed.next();
    this._destroyed.complete();
  }
}
