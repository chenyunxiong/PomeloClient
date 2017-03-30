module.exports = function(app) {
  return new Handler(app);
};

var Handler = function(app) {
  this.app = app;
};

var handler = Handler.prototype;

handler.send = function(msg, session, next) {
	
	next(null, {code: 200, msg: 'send data is ok.'});
};
